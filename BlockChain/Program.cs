using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain axecoin = new BlockChain();
            axecoin.addBlock(new BlockInfo(5, "Ronald", "Rahul"), 2);
            Console.WriteLine(axecoin.ToString());
            Console.ReadLine();

            Console.WriteLine("Is axecoin valid?: " + axecoin.isChainValid());
            Console.ReadLine();
        }
    }
}
