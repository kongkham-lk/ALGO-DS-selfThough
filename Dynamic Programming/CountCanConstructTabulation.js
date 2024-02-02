//count how many way the array of string can construct the target work
const countCanConstruct = (target, words) => {
    const table = Array(target.length + 1).fill(0);
    table[0]++;

    for(let i = 0; i < table.length; i++) {
        if (table[i] !== 0) {
            words.forEach(word => {
                if (target.slice(i, i + word.length) === word) {
                    table[i + word.length] += table[i];
                }
            });
        }
    }

    return table[target.length];
}

console.log(countCanConstruct("pupil", ["pil", "pu", "il", "p", "u"])); // return 4