using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.challenge
{
    class Day08 : Challenge
    {
        public static int Solve1()
        {
            var console = new Console();
            console.Run();

            return console.Accumulator;
        }

        public static int Solve2()
        {
            var pointer = 0;
            var console = new Console();
            do
            {
                console.Reset();

                for (int i = pointer; i < console.Instructions.Count; i++)
                {
                    Instruction instruction = console.Instructions[i];
                    if (instruction.Operation == "jmp" || instruction.Operation == "nop") 
                    {
                        if (instruction.Operation == "jmp")
                            instruction.Operation = "nop";
                        else if (instruction.Operation == "nop")
                            instruction.Operation = "jmp";
                        console.Instructions[i] = instruction;
                        pointer = i + 1;
                        break;
                    }
                }

                console.Run();
            } while (console.GetStatus() != 1);

            return console.Accumulator;
        }

        private class Console
        {
            private List<int> PassedPointers;

            public int Pointer;
            public int Accumulator;
            public List<Instruction> Instructions;

            public Console()
            {
                this.Reset();
            }

            public void Reset()
            {
                this.Instructions = GetInputAsStringList(8).Select(s => new Instruction(s.Substring(0, 3), int.Parse(s.Substring(4)))).ToList();
                this.Pointer = 0;
                this.Accumulator = 0;
                this.PassedPointers = new List<int>();
            }

            public void Run()
            {
                do
                {
                    this.PassedPointers.Add(this.Pointer);
                    this.Instructions[this.Pointer].Do(this);
                } while (this.GetStatus() == 0);
            }

            public int GetStatus() 
            {
                if (this.Pointer == this.Instructions.Count)
                    return 1; // Exited successfully
                if (this.PassedPointers.Contains(this.Pointer))
                    return 2; // Exited with fault
                return 0; // Running
            }
        }

        private class Instruction
        {
            public string Operation;
            public int Argument;

            public Instruction(string op, int arg) 
            {
                this.Operation = op;
                this.Argument = arg;
            }

            public void Do(Console console) 
            {
                switch (this.Operation) {
                    case "acc":
                        console.Accumulator += this.Argument;
                        console.Pointer++;
                        break;
                    case "jmp":
                        console.Pointer += this.Argument;
                        break;
                    case "nop":
                        console.Pointer++;
                        break;
                }
            }
        }
    }
}
