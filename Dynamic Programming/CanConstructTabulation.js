// check if given array of string can construct the target work
const canConstruct = (target, words) => {
    var table = Array(target.length + 1).fill(false);
    table[0] = true;

    for (let i = 0; i <= target.length; i++) {
        if (table[i] === true) {
            words.forEach(word => {
                if (target.slice(i, i + word.length) === word) {
                    table[i + word.length] = true;
                }
            });
        }
    }
    
    return table[target.length];
}

console.log(canConstruct("stranger", ["st", "ger", "stran", "ran", "ge"]));
console.log(canConstruct("stranger", ["st", "stran", "ran", "ge", "ger"]));
console.log(canConstruct("stranger", ["st", "ger", "stra", "ran", "ge"]));