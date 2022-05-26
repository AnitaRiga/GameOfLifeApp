using System;

namespace GameOfLifeApp
{
    public interface ICommunicator
    {
        int GetBoundedResponse(string message, int minValue, int maxValue);
        void StartPage();
    }
}
