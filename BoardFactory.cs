using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAssignment_LiorSaid
{
    public class BoardFactory
    {
        public BoardFactory()
        {

        }

        private int findSnakeTailPosition(int i_SnakeHeadPosition, ISet<int> i_RandomPositions)
        {
            int endRange;

            if (i_SnakeHeadPosition % 10 == 0)
            {
                endRange = i_SnakeHeadPosition - 10;
            }
            else
            {
                endRange = i_SnakeHeadPosition - (i_SnakeHeadPosition % 10);
            }

            int snakeTailPosition = getRandomNumberBetweenRange(1, endRange, i_RandomPositions);

            return snakeTailPosition;
        }

        private Snake createSnake(int i_StartRange, int i_EndRange, ISet<int> i_RandomPositions)
        {
            int snakeHeadPosition = getRandomNumberBetweenRange(i_StartRange, i_EndRange, i_RandomPositions);

            i_RandomPositions.Add(snakeHeadPosition);
            int snakeTailPosition = findSnakeTailPosition(snakeHeadPosition, i_RandomPositions);

            i_RandomPositions.Add(snakeTailPosition);
            Snake snake = new Snake(snakeHeadPosition, snakeTailPosition);

            return snake;
        }
        
        private int findEndLadderPosition(int i_StartLadderPosition, int i_EndRange, ISet<int> i_RandomPositions)
        {
            int startRangeForEndLadder;

            if(i_StartLadderPosition % 10 == 0)
            {
                startRangeForEndLadder = i_StartLadderPosition + 1;
            }
            else
            {
                startRangeForEndLadder = (((i_StartLadderPosition / 10) + 1) * 10) + 1; 
            }

            int endLadderPosition = getRandomNumberBetweenRange(startRangeForEndLadder, i_EndRange, i_RandomPositions);

            return endLadderPosition;
        }

        private Ladder createLadder(int i_StartRange, int i_EndRange, ISet<int> i_RandomPositions)
        {
            int startLadderPosition = getRandomNumberBetweenRange(i_StartRange, i_EndRange, i_RandomPositions);

            i_RandomPositions.Add(startLadderPosition);
            int endLadderPosition = findEndLadderPosition(startLadderPosition, 101, i_RandomPositions);

            i_RandomPositions.Add(endLadderPosition); 
            Ladder ladder = new Ladder(startLadderPosition, endLadderPosition);

            return ladder;  
        }

        private GoldSquare createGoldSquare(int i_StartRange, int i_EndRange, ISet<int> i_RandomPositions, out int io_GoldSquareNumber)
        {            
            io_GoldSquareNumber = getRandomNumberBetweenRange(i_StartRange, i_EndRange, i_RandomPositions);
            i_RandomPositions.Add(io_GoldSquareNumber);
            GoldSquare goldSquare = new GoldSquare();

            return goldSquare;
        }

        private int getRandomNumberBetweenRange(int i_StartRange, int i_EndRange, ISet<int> i_RandomNumbers)
        {
            Random random = new Random();
            int randomNumber;

            do
            {
                randomNumber = random.Next(i_StartRange, i_EndRange);
            } while (i_RandomNumbers.Contains(randomNumber));

            return randomNumber;    
        }

        public Board CreateBoard(int i_NumberOfSnakes, int i_NumberOfLadders)
        {
            ISet<int> randomEffectSet = new HashSet<int>();
            Dictionary<int, SquareEffect> squareNumberToSquareEffect = new Dictionary<int, SquareEffect>();
            for (int randomCounter = 0; randomCounter < i_NumberOfSnakes; randomCounter++)
            {
                Snake snake = createSnake(11, 100, randomEffectSet);
                squareNumberToSquareEffect.Add(snake.SnakeHeadPosition, snake);
            }
            
            for (int randomCounter = 0; randomCounter < i_NumberOfLadders; randomCounter++)
            {
                Ladder ladder = createLadder(2, 91, randomEffectSet);

                squareNumberToSquareEffect.Add(ladder.LadderStartPosition, ladder);
            }

            for (int goldSquareCounter = 0; goldSquareCounter < 2; goldSquareCounter++)
            {
                int goldSquareNumber;

                GoldSquare goldSquare = createGoldSquare(2, 100, randomEffectSet, out goldSquareNumber);
                 
                squareNumberToSquareEffect.Add(goldSquareNumber, goldSquare);
            }

            Square[] squaresArray = new Square[101];

            for(int squareNumber = 1; squareNumber < squaresArray.Length; squareNumber++)
            {
                SquareEffect? squareEffect;

                squareNumberToSquareEffect.TryGetValue(squareNumber, out squareEffect);
                Square square = new Square(squareNumber, squareEffect);

                squaresArray[squareNumber] = square;
            }   

            Board board = new Board(squaresArray);

            return board;
        }
    }
}
