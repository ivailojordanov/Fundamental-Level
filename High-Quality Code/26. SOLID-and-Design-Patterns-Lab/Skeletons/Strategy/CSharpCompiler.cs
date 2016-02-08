﻿namespace SharpCompiler
{
    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Text;
    using Microsoft.CSharp;
    using Exceptions;
    using ValidationStrategies;

    public class CSharpCompiler
    {
        private CompilerResults compiledProgram;
        private CompilerParameters compilerParameters;
        private CSharpCodeProvider csharpCodeProvider;

        private IValidationStrategy strategy;

        public CSharpCompiler(IValidationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public CSharpCompiler()
        {
        }

        public void Compile(string codeString)
        {
            this.Preprocess(codeString);

            if (this.compilerParameters == null)
            {
                this.compilerParameters = InitializeCompilerParameters();
            }

            if (this.csharpCodeProvider == null)
            {
                this.csharpCodeProvider = new CSharpCodeProvider();
            }

            this.compiledProgram = this.csharpCodeProvider.CompileAssemblyFromSource(
                this.compilerParameters, codeString);

            // Check for compilation errors
            if (this.compiledProgram.Errors.HasErrors)
            {
                var errorMsg = new StringBuilder();
                foreach (CompilerError ce in this.compiledProgram.Errors)
                {
                    errorMsg.AppendLine(ce.ToString());
                }

                throw new CompilationException(errorMsg.ToString());
            }
        }

        public void Execute(string entryClassName)
        {
            Assembly assembly = this.compiledProgram.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType(entryClassName);
            MethodInfo methInfo = type.GetMethod("Main");

            methInfo.Invoke(null, null);
        }

        protected void Preprocess(string codeString)
        {
            if (this.strategy != null)
            {
                this.strategy.Validate(codeString);
            }
        }

        private static CompilerParameters InitializeCompilerParameters()
        {
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

            return compilerParams;
        }
    }
}
