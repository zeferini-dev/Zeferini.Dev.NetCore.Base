# Define o diretório base para o projeto de testes
$basePath = "NetCore.Base.Tests"

# Cria a pasta base do projeto de testes
New-Item -ItemType Directory -Path $basePath -Force

# Cria o arquivo .csproj
$csprojContent = @"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="../NetCore.Base/NetCore.Base.csproj" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3" />
    <PackageReference Include="Moq" Version="4.16.1" />
  </ItemGroup>
</Project>
"@
Set-Content -Path "$basePath/NetCore.Base.Tests.csproj" -Value $csprojContent

# Cria os arquivos de teste com conteúdo
$testFiles = @{
    "PessoaTest.cs" = @"
using Xunit;
using NetCore.Base.Model;

namespace NetCore.Base.Tests
{
    public class PessoaTest
    {
        [Fact]
        public void TestPessoaName()
        {
            var pessoa = new Pessoa { Nome = "Test" };
            Assert.Equal("Test", pessoa.Nome);
        }
    }
}
"
    "PessoaFisicaTest.cs" = @"
using Xunit;
using NetCore.Base;

namespace NetCore.Base.Tests
{
    public class PessoaFisicaTest
    {
        [Fact]
        public void TestPessoaFisicaInitialization_ValidData_ShouldInitialize()
        {
            var pessoaFisica = new PessoaFisica("id123", "12345678909", "João", "", "Silva", "insertedBy123");
            Assert.Equal("João", pessoaFisica.PreNome);
            Assert.Equal("12345678909", pessoaFisica.CPF);
        }
    }
}
"
    "PessoaJuridicaTest.cs" = @"
using Xunit;
using NetCore.Base.Model;

namespace NetCore.Base.Tests
{
    public class PessoaJuridicaTest
    {
        [Fact]
        public void TestPessoaJuridicaCNPJ()
        {
            var pessoaJuridica = new PessoaJuridica { CNPJ = "12345678000195" };
            Assert.Equal("12345678000195", pessoaJuridica.CNPJ);
        }
    }
}
"
    "CPFValidatorTest.cs" = @"
using Xunit;
using NetCore.Base;

namespace NetCore.Base.Tests
{
    public class CPFValidatorTest
    {
        [Theory]
        [InlineData("12345678909", true)]
        [InlineData("00000000000", false)]
        [InlineData("11111111111", false)]
        [InlineData("", false)]
        public void TestCPFValidation(string cpf, bool expectedResult)
        {
            var validator = new CPFValidator(cpf);
            Assert.Equal(expectedResult, validator.Result);
        }
    }
}
"
    "CNPJValidatorTest.cs" = @"
using Xunit;
using NetCore.Base;

namespace NetCore.Base.Tests
{
    public class CNPJValidatorTest
    {
        [Theory]
        [InlineData("12345678000195", true)]
        [InlineData("00000000000000", false)]
        [InlineData("", false)]
        public void TestCNPJValidation(string cnpj, bool expectedResult)
        {
            var validator = new CNPJValidator(cnpj);
            Assert.Equal(expectedResult, validator.Result);
        }
    }
}
"
    "NumberValidatorTest.cs" = @"
using Xunit;
using NetCore.Base;

namespace NetCore.Base.Tests
{
    public class NumberValidatorTest
    {
        [Fact]
        public void TestValidateInt_PositiveNumber_ReturnsTrue()
        {
            Assert.True(NumberValidator.ValidateInt(10));
        }

        [Fact]
        public void TestValidateInt_NegativeNumber_ReturnsFalse()
        {
            Assert.False(NumberValidator.ValidateInt(-5));
        }
    }
}
"
    "RuleValidatorTest.cs" = @"
using System;
using Xunit;
using NetCore.Base;

namespace NetCore.Base.Tests
{
    public class RuleValidatorTest
    {
        [Fact]
        public void TestRuleValidator_WhenError_ShouldThrowException()
        {
            var validator = RuleValidator.New().When(true, "Sample error");
            Assert.Throws<BaseException>(() => validator.ThrowExceptionIfExists());
        }

        [Fact]
        public void TestRuleValidator_WhenNoError_ShouldNotThrowException()
        {
            var validator = RuleValidator.New();
            validator.ThrowExceptionIfExists();
        }
    }
}
"
}

# Cria cada arquivo de teste com seu conteúdo
foreach ($fileName in $testFiles.Keys) {
    $filePath = "$basePath/$fileName"
    $content = $testFiles[$fileName]
    Set-Content -Path $filePath -Value $content
}
