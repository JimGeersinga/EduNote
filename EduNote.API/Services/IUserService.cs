using EduNote.API.EF.Interfaces;
using EduNote.API.EF.Models;
using EduNote.API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduNote.API.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        string GenerateToken(User user);
        (string hash, string salt) HashPassword(string password);
    }
}
