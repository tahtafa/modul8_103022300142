using System;
using modul8_103022300142;


class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();

        if (config.config.lang == "en")
        {
            Console.WriteLine($"Please insert the amount of money to transfer: ");

        }
        else
        {
            Console.WriteLine($"Masukkan jumlah uang yang akan di-transfer:");

        }

        int amount = Convert.ToInt32(Console.ReadLine());
        int biayatransfer = 0;
        if (config.config.transfer.threshold >= amount)
        { 
            biayatransfer = config.config.transfer.low_fee;
        }
        else
        {
            biayatransfer = config.config.transfer.high_fee;
        }

        int totalbiayatransfer = biayatransfer + amount;
        if (config.config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biayatransfer}");
            Console.WriteLine($"Total amount = {totalbiayatransfer}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {biayatransfer}");
            Console.WriteLine($"Total biaya = {totalbiayatransfer}");
        }

    }
}
