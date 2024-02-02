// find the possible combination from the given array of string that can construct as the target string
const allConstruct = (target, words) => {
    const table = Array(target.length + 1)
        .fill()
        .map(() => []);

    table[0] = [[]];

    for (let i = 0; i <= target.length; i++) {
        words.forEach(word => {
            if (target.slice(i, i + word.length) === word) {
                const newArray = table[i].map(subArray => [...subArray, word]); // adding new word to array without make change to the actual array
                table[i + word.length].push(...newArray); // combine 2 array of array into 1 and make change to actual array
            }
        });
    }
    return table[target.length];
}

console.log(allConstruct("pupil", ["pil", "pu", "il", "p", "u"])); 
// return 
// [
//     [ 'pu', 'pil' ],
//     [ 'p', 'u', 'pil' ],
//     [ 'pu', 'p', 'il' ],
//     [ 'p', 'u', 'p', 'il' ]
// ]