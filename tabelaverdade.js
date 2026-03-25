// Conectivos lógicos e tabela verdade em JavaScript

const valores = [true, false];

console.log("=== TABELA VERDADE - AND (&&) ===");
for (let a of valores) {
  for (let b of valores) {
    console.log(`A: ${a}, B: ${b} => A && B = ${a && b}`);
  }
}

console.log("\n=== TABELA VERDADE - OR (||) ===");
for (let a of valores) {
  for (let b of valores) {
    console.log(`A: ${a}, B: ${b} => A || B = ${a || b}`);
  }
}

console.log("\n=== TABELA VERDADE - NOT (!) ===");
for (let a of valores) {
  console.log(`A: ${a} => !A = ${!a}`);
}

console.log("\n=== EXPRESSÕES LÓGICAS COMBINADAS ===");
const A = true;
const B = false;

console.log(`A = ${A}, B = ${B}`);
console.log(`A && B = ${A && B}`);
console.log(`A || B = ${A || B}`);
console.log(`!(A && B) = ${!(A && B)}`);
console.log(`!A || B = ${!A || B}`);

console.log("\n=== EXEMPLO PRÁTICO ===");
const usuarioLogado = true;
const temPermissao = false;

const podeAcessar = usuarioLogado && temPermissao;

console.log(`Usuário logado: ${usuarioLogado}`);
console.log(`Tem permissão: ${temPermissao}`);
console.log(`Pode acessar o sistema? ${podeAcessar}`);
