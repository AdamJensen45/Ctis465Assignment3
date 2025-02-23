﻿using CORE.APP.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.Users.Domain
{
    public class User : Entity
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<UserSkill> UserSkills { get; set; } = new List<UserSkill>();

        [NotMapped]
        public List<int> SkillIds 
        { 
            get => UserSkills.Select(us => us.SkillId).ToList();
            set => UserSkills = value.Select(v => new UserSkill() { SkillId = v }).ToList(); 
        }
    }
}
