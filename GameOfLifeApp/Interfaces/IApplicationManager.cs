using System;

namespace GameOfLifeApp
{
    public interface IApplicationManager
    {
        void RunApplication(int countOfRows, int countOfColumns);
        void RunApplication();
    }
}
