﻿
namespace Anycmd.Ac.ViewModels.Infra.AppSystemViewModels
{
    using Engine;
    using Engine.Ac.InOuts;
    using Engine.Ac.Messages.Infra;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public class AppSystemUpdateInput : ManagedPropertyValues, IAppSystemUpdateIo
    {
        public AppSystemUpdateInput()
        {
            HecpOntology = "AppSystem";
            HecpVerb = "Update";
        }

        public string HecpOntology { get; private set; }

        public string HecpVerb { get; private set; }

        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SsoAuthAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(1)]
        public int IsEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int SortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid PrincipalId { get; set; }

        public IAnycmdCommand ToCommand(IUserSession userSession)
        {
            return new UpdateAppSystemCommand(userSession, this);
        }
    }
}
