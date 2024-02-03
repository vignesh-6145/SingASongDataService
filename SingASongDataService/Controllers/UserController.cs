using Microsoft.AspNetCore.Mvc;
using SingASongDataService.Data;
using SingASongDataService.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SingASongDataService.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        SingASongContext _context;
        public UserController()
        {
            _context = new SingASongContext();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate()
        {
            //Encoding
            // var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
            //string encodeString = Convert.ToBase64String(byteArray);
            //Decoding
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var CredentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(CredentialBytes).Split(new[] { ':' }, 2);
                string email = credentials[0];
                string Password = credentials[1];
                try
                {
                    string actualPassword = _context.Users.First(usr => usr.Email.Equals(email)).Password;
                    if (actualPassword.Equals(Password))
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("Password Missmatch");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No User With Email {email}");
                    Console.WriteLine(ex.Message);
                    return NotFound("UserNotFound");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to decode credentials");
                Console.WriteLine(ex.Message);
                return BadRequest("Unable to parse Credentials");
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUser([FromBody]User User)
        {
            Country Country;
            State State;
            
            try
            {
                //Check if user alread present or not
                var userEmail = _context.Users.First(usr => usr.Email.Equals(User.Email)).Email;
                Console.WriteLine($"User with email {userEmail} already exists");
                return BadRequest("User ALready Registered");
            }
            catch(Exception ex) {
                //check if state and country are valid
                try
                {
                    //Check Country
                    Country = _context.Countries.First(usr => usr.Name.Equals(User.Country.Name));
                    //Check state
                    try
                    {
                        State = _context.States.First(usr => usr.Name.Equals(User.State.Name));
                        try
                        {
                            User.StateID = State.StateID;
                            User.State = State;
                            User.CountryID = Country.CountryID;
                            User.Country = Country;
                            _context.Users.Add(User);
                            _context.SaveChanges();
                            return Ok("User Registration Successful");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Failed to Insert User");
                            Console.WriteLine(e.Message);
                            return BadRequest("Unable to insert User");
                        }
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine($"State Not found in records {User.State.Name}");
                        Console.WriteLine(se.Message);
                        return BadRequest("State Notfound");
                    }
                }
                catch(Exception ce)
                {
                    Console.WriteLine($"State Not found in records {User.State.Name}");
                    Console.WriteLine(ce.Message);
                    return BadRequest("Country Not Found");
                }
                //add them to the db
            }
            return BadRequest("Something wentwrong");
        }
    }
}
