﻿using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using BangaloreUniversityLearningSystem.Core;
using BangaloreUniversityLearningSystem.Models;
using BangaloreUniversityLearningSystem.Utilities;
using BangaloreUniversityLearningSystem.Interfaces;

namespace BangaloreUniversityLearningSystem.Controllers
{
    public abstract class Controller
    {
        private const char NamespaceSeparator = '.';
        private const string ControllerSuffix = "Controller";

        protected IBangaloreUniversityData Data { get; set; }

        public User CurrentUser { get; protected set; }

        public bool HasCurrentUser
        {
            get
            {
                return this.CurrentUser != null;
            }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);

            string controllerName = this.GetType().Name
                .Replace(ControllerSuffix, string.Empty);

            string actionName = new StackTrace()
                .GetFrame(1)
                .GetMethod().Name;

            string fullPath = string.Format("{0}.Views.{1}.{2}", baseNamespace, controllerName, actionName);

            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            // BOTTLENECK: Remove unused foreach
            var isInRole = roles.Any(role => this.CurrentUser.IsInRole(role));
            if (!isInRole)
            {
                throw new AuthorizationFailedException("The current user is not authorized to perform this operation.");
            }
        }
    }
}
