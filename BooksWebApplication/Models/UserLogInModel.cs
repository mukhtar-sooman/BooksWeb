using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.WindowsAzure.MediaServices.Client;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace BooksWebApplication.Models
{
    public class UserLogIModel
    {
        public string Email { get; set; }
        public string Password { get; set; }    
    }
    public enum loginTypes
    {
        defulte = 0,
        User = 1,
        coustomer = 2,
    }
    public class UserLogMethod
    {
        public List<Claim> Claims { get; set; }
    }
}