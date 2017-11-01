using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadTest.TaskScheduling {
  class Program {
    static void Main(string[] args) {

      Tasks1();
      Console.ReadLine();
    }

    public static Task Tasks1() {

      return Task.WhenAll(Task.Delay(20000), Task.Delay(40000));
    }
  }
}
