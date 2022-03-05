using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


//Name: Amir Aslamov
//COP4365-Software System Development
//Homework #2:The Smarter Stoplight Problem

namespace Smarter_Stoplight_Problem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //we create a stopwatch object that will determine the overall running time
        //of the program we will create a stopwatch object and a timespan object
        //outside to make them global
        Stopwatch stopwatch_overall = new Stopwatch();
        TimeSpan time_span_overall;

        //we also create 4 stoplight objects
        Stoplight north_stoplight = new Stoplight();
        Stoplight south_stoplight = new Stoplight();
        Stoplight east_stoplight = new Stoplight();
        Stoplight west_stoplight = new Stoplight();


        //Method Name: CycleNorth
        //Description: this method simulates the cycle of the colors of the north stoplight:
        //it creates a seperate stopwatch object and correspondingly changes the labels, color properties
        //of the picture boxes and the color attribute of the north stoplight object
        public void CycleNorth()
        {
            //we create a seperate timer for this stoplight
            Stopwatch north_watch = new Stopwatch();
            //we start the timer
            north_watch.Start();
            //we get the timspan of seconds elapsed
            TimeSpan ts_north = north_watch.Elapsed;

            //first the stoplight has to be green for 9 seconds
            //so we change the backcolor of the picture box
            North_Green_PX.BackColor = Color.Green;
            //the rest of the lights will turn to gray color
            North_Red_PX.BackColor = Color.Gray;
            North_Yellow_PX.BackColor = Color.Gray;

            //refresh the GUI
            Refresh();
            //we also change the color property of the north stopligh object
            north_stoplight.ChangeColor("Green");

            //green for 9 seconds, yellow for 3 seconds, the rest is red, we technically need 
            //the timing for the green and yellow colors, and the red color is just a default color
            //after a total of 12 seconds
            //but after 6 seconds this function calls the function for the south stoplight cycle
            //we will change the north light color inside that south stoplight cycle function
            while (ts_north.Seconds < 6)
            {
                //we keep getting the seconds elapsed from the overall timer
                time_span_overall = stopwatch_overall.Elapsed;
                //we keep dynamically changing the text value of the timer label
                Timer_LBL.Text = time_span_overall.Seconds.ToString();
                Refresh();

                //we get the seconds elapsed in the timer for the north stoplight
                ts_north = north_watch.Elapsed;
            }
            //if 6 seconds have passed, we trigger the south stoplight cycle
            CycleSouth();
        }


        //Method Name: CycleSouth
        //Description: this method simulates the cycle of the colors of the south stoplight:
        //it creates a seperate stopwatch object and correspondingly changes the labels, color properties
        //of the picture boxes and the color attribute of the south stoplight object
        public void CycleSouth()
        {
            //we create a seperate timer for this stoplight
            Stopwatch south_watch = new Stopwatch();
            //we start the timer
            south_watch.Start();
            //we get the timspan of seconds elapsed
            TimeSpan ts_south = south_watch.Elapsed;

            //first the stoplight has to be green for 9 seconds
            //so we change the backcolor of the picture box
            South_Green_PX.BackColor = Color.Green;
            //the rest of the lights will turn to gray color
            South_Red_PX.BackColor = Color.Gray;
            South_Yellow_PX.BackColor = Color.Gray;

            //refresh the GUI
            Refresh();
            //we also change the color property of the south stopligh object
            south_stoplight.ChangeColor("Green");

            //green for 9 seconds, yellow for 3 seconds, the rest is red, we technically need 
            //the timing for the green and yellow colors, and the red color is just a default color
            //after a total of 12 seconds
            while (ts_south.Seconds < 12)
            {
                //we keep getting the seconds elapsed from the overall timer
                time_span_overall = stopwatch_overall.Elapsed;
                //we keep dynamically changing the text value of the timer label
                Timer_LBL.Text = time_span_overall.Seconds.ToString();
                Refresh();

                //we get the seconds elapsed in the timer for the north stoplight
                ts_south = south_watch.Elapsed;

                //if the timer for the south stoplight is 2, it means 3 seconds have passed, which means
                //a total of 9 seconds have passed for the north stoplight stopwatch: we change the color to yellow
                if (ts_south.Seconds == 2)
                {
                    north_stoplight.ChangeColor("Yellow");
                    //we turn on the yellow light
                    North_Yellow_PX.BackColor = Color.Yellow;
                    //the rest of the lights will turn to gray color
                    North_Red_PX.BackColor = Color.Gray;
                    North_Green_PX.BackColor = Color.Gray;
                    Refresh();
                }
                //else if it is 5, 6 seconds have passed - total of 12 seconds for the north stoplight stopwatch: 
                //we change north light color to red
                else if (ts_south.Seconds == 5)
                {
                    //we leave the stoplight at the default color of red
                    north_stoplight.ChangeColor("Red");
                    North_Red_PX.BackColor = Color.Red;
                    //we turn the rest of the light to the gray color
                    North_Green_PX.BackColor = Color.Gray;
                    North_Yellow_PX.BackColor = Color.Gray;
                    Refresh();
                }
                //if 9 seconds have passed, we change the stoplight color to yellow
                else if (ts_south.Seconds == 8)
                {
                    south_stoplight.ChangeColor("Yellow");
                    //we turn on the yellow light
                    South_Yellow_PX.BackColor = Color.Yellow;
                    //we turn the rest of the colors to gray color
                    South_Red_PX.BackColor = Color.Gray;
                    South_Green_PX.BackColor = Color.Gray;
                    Refresh();
                }
            }

            //we leave the stoplight at the default color of red
            south_stoplight.ChangeColor("Red");
            South_Red_PX.BackColor = Color.Red;
            //we turn the rest of the light to gray color
            South_Green_PX.BackColor = Color.Gray;
            South_Yellow_PX.BackColor = Color.Gray;
            Refresh();
        }


        //Method Name: CycleEast
        //Description: this method simulates the cycle of the colors of the east stoplight:
        //it creates a seperate stopwatch object and correspondingly changes the labels, color properties
        //of the picture boxes and the color attribute of the south stoplight object
        public void CycleEast()
        {
            //we create a seperate timer for this stoplight
            Stopwatch east_watch = new Stopwatch();
            //we start the timer
            east_watch.Start();
            //we get the timspan of seconds elapsed
            TimeSpan ts_east = east_watch.Elapsed;

            //first the stoplight has to be green for 9 seconds
            //so we change the backcolor of the picture box
            East_Green_PX.BackColor = Color.Green;
            //the rest of the colors of the stoplight have to be gray
            East_Red_PX.BackColor = Color.Gray;
            East_Yellow_PX.BackColor = Color.Gray;

            //refresh the GUI
            Refresh();
            //we also change the color property of the south stopligh object
            east_stoplight.ChangeColor("Green");

            //green for 9 seconds, yellow for 3 seconds, the rest is red, we technically need 
            //the timing for the green and yellow colors, and the red color is just a default color
            //after a total of 12 seconds
            //but after 6 seconds this function calls the function for the west stoplight cycle
            //we will change the east light color inside that west stoplight cycle function
            while (ts_east.Seconds < 6)
            {
                //we keep getting the seconds elapsed from the overall timer
                time_span_overall = stopwatch_overall.Elapsed;
                //we keep dynamically changing the text value of the timer label
                Timer_LBL.Text = time_span_overall.Seconds.ToString();
                Refresh();

                //we get the seconds elapsed in the timer for the north stoplight
                ts_east = east_watch.Elapsed;
            }

            //if 6 seconds have passed, we trigger the west stoplight cycle
            CycleWest();
        }


        //Method Name: CycleWest
        //Description: this method simulates the cycle of the colors of the west stoplight:
        //it creates a seperate stopwatch object and correspondingly changes the labels, color properties
        //of the picture boxes and the color attribute of the south stoplight object
        public void CycleWest()
        {
            //we create a seperate timer for this stoplight
            Stopwatch west_watch = new Stopwatch();
            //we start the timer
            west_watch.Start();
            //we get the timspan of seconds elapsed
            TimeSpan ts_west = west_watch.Elapsed;

            //first the stoplight has to be green for 9 seconds
            //so we change the backcolor of the picture box
            West_Green_PX.BackColor = Color.Green;
            //the rest of the colors of the stoplight have to be gray color
            West_Red_PX.BackColor = Color.Gray;
            West_Yellow_PX.BackColor = Color.Gray;

            //refresh the GUI
            Refresh();
            //we also change the color property of the south stopligh object
            west_stoplight.ChangeColor("Green");

            //green for 9 seconds, yellow for 3 seconds, the rest is red, we technically need 
            //the timing for the green and yellow colors, and the red color is just a default color
            //after a total of 12 seconds
            while (ts_west.Seconds < 12)
            {
                //we keep getting the seconds elapsed from the overall timer
                time_span_overall = stopwatch_overall.Elapsed;
                //we keep dynamically changing the text value of the timer label
                Timer_LBL.Text = time_span_overall.Seconds.ToString();
                Refresh();

                //we get the seconds elapsed in the timer for the north stoplight
                ts_west = west_watch.Elapsed;

                //if the timer for the west stoplight is 2, it means 3 seconds have passed, which means
                //a total of 9 seconds have passed for the east stoplight stopwatch: we change the color to yellow
                if (ts_west.Seconds == 2)
                {
                    east_stoplight.ChangeColor("Yellow");
                    //we change turn the yellow light
                    East_Yellow_PX.BackColor = Color.Yellow;
                    //the rest of the colors will be gray
                    East_Green_PX.BackColor = Color.Gray;
                    East_Red_PX.BackColor = Color.Gray;
                    Refresh();
                }
                //else if it is 5, 6 seconds have passed - total of 12 seconds for the east stoplight stopwatch: 
                //we change east light color to red
                else if (ts_west.Seconds == 5)
                {
                    //we leave the stoplight at the default color of red
                    east_stoplight.ChangeColor("Red");
                    East_Red_PX.BackColor = Color.Red;
                    //the rest turn to gray
                    East_Yellow_PX.BackColor = Color.Gray;
                    East_Green_PX.BackColor = Color.Gray;
                    Refresh();
                }
                //if 9 seconds have passed, we change the stoplight color to yellow
                else if (ts_west.Seconds == 8)
                {
                    west_stoplight.ChangeColor("Yellow");
                    //we turn on the yellow light 
                    West_Yellow_PX.BackColor = Color.Yellow;
                    //the rest of the lights will turn to gray
                    West_Red_PX.BackColor = Color.Gray;
                    West_Green_PX.BackColor = Color.Gray;
                    Refresh();
                }
            }

            //we leave the stoplight at the default color of red
            west_stoplight.ChangeColor("Red");
            West_Red_PX.BackColor = Color.Red;
            //the rest of the lights till turn to gray color
            West_Green_PX.BackColor = Color.Gray;
            West_Yellow_PX.BackColor = Color.Gray;
            Refresh();
        }


        private void Start_BTN_Click(object sender, EventArgs e)
        {
            //we trigger the global timer
            stopwatch_overall.Start();
            time_span_overall = stopwatch_overall.Elapsed;

            //The idea of the program:
            //CYCLE:
            //NORTH starts GREEN
            //After 6 seconds => SOUTH turns GREEN
            //After SOUTH turns RED => EAST turns GREEN
            //After 6 seconds => WEST turns GREEN
            //After WEST turns RED => NORTH starts GREEN

            //we will keep running the system while 60 seconds are not passed
            while (time_span_overall.Seconds <= 60)
            {
                time_span_overall = stopwatch_overall.Elapsed;
                //we change the text value of the timer label to display the seconds elapsed dynamically
                Timer_LBL.Text = time_span_overall.Seconds.ToString();
                //refresh the GUI
                Refresh();

                //the cycle starts from the north stoplight
                //the north stoplight, after 6 seconds, triggers the south stoplight
                //once the control returns to this function after the 2 calls of the helper
                //functions, we know that the south stoplight finished its cycle, so we start
                //the east stoplight cycle, which in turn triggers the west stoplight after 6 seconds
                CycleNorth();
                CycleEast();
            }
        }
    }
}
