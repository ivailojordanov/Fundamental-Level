﻿using System;
using System.Text;
using BangaloreUniversityLearningSystem.Models;

namespace BangaloreUniversityLearningSystem.Views.Users
{
    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var userModel = this.Model as User;
            viewResult.AppendFormat("User {0} logged in successfully.{1}", userModel.Username, Environment.NewLine);
        }
    }
}