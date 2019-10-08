using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Button
    {
        private String someText;
        public Button()
        {
            someText = "";
        }

        public String getText()
        {
            return someText;
        }
    }
    
}
