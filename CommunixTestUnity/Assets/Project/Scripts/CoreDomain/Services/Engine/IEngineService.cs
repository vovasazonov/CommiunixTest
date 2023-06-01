using System;

namespace Project.CoreDomain.Services.Engine
{
    public interface IEngineService
    {
        event Action Updating;
        event Action FixedUpdating;
    }
}