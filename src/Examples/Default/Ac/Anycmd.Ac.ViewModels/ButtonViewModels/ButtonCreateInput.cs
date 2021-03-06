﻿
namespace Anycmd.Ac.ViewModels.ButtonViewModels
{
    using Engine.Ac.UiViews;
    using Engine.InOuts;
    using Engine.Messages;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 
    /// </summary>
    public class ButtonCreateInput : EntityCreateInput, IButtonCreateIo
    {
        public ButtonCreateInput()
        {
            HecpOntology = "Button";
            HecpVerb = "Create";
        }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string CategoryCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int SortCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(1)]
        public int IsEnabled { get; set; }

        public override IAnycmdCommand ToCommand(IAcSession acSession)
        {
            return new AddButtonCommand(acSession, this);
        }
    }
}
