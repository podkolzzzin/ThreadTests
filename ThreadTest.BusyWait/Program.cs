namespace ThreadTest.BusyWait {

  class Program {

    public static bool SomethingIsDone {
      get;
      set;
    }

    private static void BusyWait() {

      while (!SomethingIsDone)
        ;

      #region Process Result
      #endregion
    }

    static void Main(string[] args) {
      BusyWait();
    }
  }
}
