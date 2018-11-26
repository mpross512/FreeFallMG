using System;

namespace FreeFall.Framework
{

    public class ScreenManager
    {

        private ScreenManager screenManager;

        public ScreenManager()
        {

        }

        public ScreenManager GetInstance() {
            if (screenManager == null)
                screenManager = new ScreenManager();
            return screenManager;
        }

    }

}
