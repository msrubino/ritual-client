using System;

public interface IRitualBehavior
{

    event Action DidComplete;
    void Begin();

}
