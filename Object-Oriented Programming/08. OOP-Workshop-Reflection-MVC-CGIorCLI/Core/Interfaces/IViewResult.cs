﻿namespace WebPage.Core.Interfaces
{
    public interface IViewResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}
