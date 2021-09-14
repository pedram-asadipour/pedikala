using System;
using System.ComponentModel.DataAnnotations;
using _01_Framework.Application;

namespace AccountManagement.Application.Contract.Role
{
    public class EditColleagueRole
    {
        public long Id { get; set; }

        [Range(1,int.MaxValue,ErrorMessage = ValidationMessages.IsRequired)]
        public long RoleId { get; set; }
    }
}