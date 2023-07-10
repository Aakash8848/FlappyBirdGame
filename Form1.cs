namespace FlappyBirdGame
{
    public partial class FlappyBirdGameForm : Form
    {
        int pipeSpeed = 5; //defaut pipeSpeed
        int gravity = 9;  //Default Gravity
        int score =  0;     //Default Score

        public FlappyBirdGameForm()
        {
            InitializeComponent();
          
        }

        private void Ground_Click(object sender, EventArgs e)
        {
            //yo fokat ma aako ho.
        }

        private void GameTimeEvent(object sender, EventArgs e)
        {
            // link the flappy bird picture box to the gravity,
            // += means it will add the speed of gravity to the picture boxes top location
            // so it will move down
            FlappyBird.Top += gravity;


            // link the bottom pipes left position to the pipe speed,
            // it will reduce the pipe speed value from the left position of the pipe picture box
            // so it will move left with each tick
            PipeBottom.Left -= pipeSpeed;

            // the same is happening with the top pipe,
            // reduce the value of pipe speed
            // from the left position of the pipe using the -= sign
            PipeTop.Left -= pipeSpeed;

            Score.Text = "Score" + score;
            //form ko width anusar pipe left jancha
            //haraudaina just left matra move garcha
            if(PipeBottom.Left <= -150)
            {
                PipeBottom.Left = 800;
                score++;
                //Score.Text = Convert.ToString(score);
            }


             if(PipeTop.Left <= -180)
            {
                PipeTop.Left = 850;
                score++;
                Score.Text = Convert.ToString(score);
            }
            if (FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds)
            || FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds)
            || FlappyBird.Bounds.IntersectsWith(Ground.Bounds)
            || FlappyBird.Top <= -25
            )
            
            
            {
                endGame();

            }
        }
        //events that define the movement of Bird

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {

            //If space key is pressed, the gravity is -15
            if (e.KeyCode == Keys.Space)

            {
                gravity = -15;
            }


        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {

            //If space key is pressed, the gravity is +15

               if (e.KeyCode == Keys.Space)
               {
                    gravity = 15;
               }

        }

        private void endGame()
        {
            GameTime.Stop();
            // += le override gardaina, append garcha j thyo tesma.
            Score.Text = "Final Score :"+ " " + score +" " + "Game Over";

            if(score >= 3)
            {
                pipeSpeed = 9;
                

            }
            if (score >= 10)
            {
                pipeSpeed = 15;


            }
        }

        
    }
}