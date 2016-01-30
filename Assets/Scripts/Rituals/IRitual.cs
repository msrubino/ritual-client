using System;

public interface IRitual
{

    event Action DidComplete;
    void Begin();

}
