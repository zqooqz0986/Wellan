using Microsoft.AnalysisServices.AdomdClient;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = RetrieveCubesAndDimensions();

            Console.Write(result);

            Console.ReadKey();
        }
        private static string RetrieveCubesAndDimensions()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            //Connect to the local server
            using (AdomdConnection conn = new AdomdConnection(@"Data Source=JOSEPH-PC\RTDEMO;Catalog=Analysis Services 教學課程;"))
            {                
                conn.Open();

                var command = conn.CreateCommand();

                command.CommandText = @"SELECT 
	
		NONEMPTY({DESCENDANTS([Product].[Product Line].CHILDREN), [Product].[Product Line] }) *
		NONEMPTY({DESCENDANTS([Measures].[Sales Amount])})
	ON COLUMNS,

		 NONEMPTY({DESCENDANTS([Due Date].[English Month Name].CHILDREN), [Due Date].[English Month Name]} )

ON ROWS
	FROM [Analysis Services 教學課程]";

                command.CommandType = CommandType.Text;
                var cellSet = command.ExecuteCellSet();

                var columns = cellSet.Axes[0];
                var columnLength = columns.Set.Tuples.Count;

                var rows = cellSet.Axes[1];
                var rowLength = rows.Set.Tuples.Count;

                var cells = cellSet.Cells;

                Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

                for (int i = 0; i < cells.Count; i++)
                {
                    if (i % columnLength == 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write("{0}\t", cells[i].FormattedValue);
                }

            }

            //Return the results
            return result.ToString();
        }

    }
}
