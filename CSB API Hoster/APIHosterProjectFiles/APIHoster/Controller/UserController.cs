using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIHoster.Controller
{
    public class UserController : ApiController
    {
        // GET api/user
        public IEnumerable<Object> Get()
        {
            Console.WriteLine("{0} -> Get() Method Called.", DateTime.Now.ToString(@"h\:mm:ss tt"));

            try
            {
                using (APIHosterDBContext context = new APIHosterDBContext())
                {
                    Console.WriteLine("{0} -> {1} User(s), returned.", DateTime.Now.ToString(@"h\:mm:ss tt"), context.Users.Count());
                    Console.WriteLine();
                    return context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} -> Exception occured - {1}", DateTime.Now.ToString(@"h\:mm:ss tt"), ex.Message);
            }

            Console.WriteLine("{0} -> NULL, returned.", DateTime.Now.ToString(@"h\:mm:ss tt"));
            Console.WriteLine();
            return null;
        }

        // GET api/user/5
        public Object Get(int id)
        {
            Console.WriteLine("{0} -> Get(id = {1}) Method Called.", DateTime.Now.ToString(@"h\:mm:ss tt"), id);

            try
            {
                using (APIHosterDBContext context = new APIHosterDBContext())
                {
                    User needUser = context.Users.FirstOrDefault(u => u.Id == id);
                    if (needUser != null)
                        Console.WriteLine("{0} -> User found. 1 User, returned.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                    else
                        Console.WriteLine("{0} -> User not found. NULL, returned.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                    Console.WriteLine();
                    return needUser;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0} -> Exception occured - {1}", ex.Message);
            }

            Console.WriteLine("{0} -> NULL, returned.", DateTime.Now.ToString(@"h\:mm:ss tt"));
            Console.WriteLine();
            return null;
        }

        // POST api/user
        public void Post([FromBody]User user)
        {
            Console.WriteLine("{0} -> Post() Method Called.", DateTime.Now.ToString(@"h\:mm:ss tt"));

            try
            {
                using (APIHosterDBContext context = new APIHosterDBContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    Console.WriteLine("{0} -> User added to database.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} -> Exception occured - {1}", DateTime.Now.ToString(@"h\:mm:ss tt"), ex.Message);
            }

            Console.WriteLine();
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]User updatedUser)
        {
            Console.WriteLine("{0} -> Put(id = {1}) Method Called.", DateTime.Now.ToString(@"h\:mm:ss tt"), id);

            try
            {
                using (APIHosterDBContext context = new APIHosterDBContext())
                {
                    User oldUser = context.Users.FirstOrDefault(u => u.Id == id);

                    if (oldUser != null)
                    {
                        oldUser.FirstName = updatedUser.FirstName;
                        oldUser.LastName = updatedUser.LastName;
                        oldUser.Mobile = updatedUser.Mobile;
                        oldUser.Gender = updatedUser.Gender;

                        context.SaveChanges();
                        Console.WriteLine("{0} -> User data updated.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                    }
                    else
                        Console.WriteLine("{0} -> User not found. Data discarded.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} -> Exception occured - {1}", DateTime.Now.ToString(@"h\:mm:ss tt"), ex.Message);
            }
            
            Console.WriteLine();
        }
        
        // DELETE api/demo/5
        public void Delete(int id)
        {
            Console.WriteLine("{0} -> Delete(id = {1}) Method Called.", DateTime.Now.ToString(@"h\:mm:ss tt"), id);

            try
            {
                using (APIHosterDBContext context = new APIHosterDBContext())
                {
                    User deleteUser = context.Users.FirstOrDefault(u => u.Id == id);
                    if (deleteUser != null)
                    {
                        context.Users.Remove(deleteUser);
                        context.SaveChanges();
                        Console.WriteLine("{0} -> User deleted from database.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                    }
                    else
                        Console.WriteLine("{0} -> User not found. Data discarded.", DateTime.Now.ToString(@"h\:mm:ss tt"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} -> Exception occured - {1}", DateTime.Now.ToString(@"h\:mm:ss tt"), ex.Message);
            }
            
            Console.WriteLine();
        }
    }
}
