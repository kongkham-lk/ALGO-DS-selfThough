
const canConsttruct = (target, wordBank) => {
    if (target === "") return true;

    for(let word of wordBank) {
        if (target.indexOf(word) === 0){
            const tempTarget = target.slice(word.length);
            if (canConsttruct(tempTarget, wordBank)){
                return true;
            }
        }
    }
    return false;
}
const canConsttructMem = (target, wordBank, memo = {}) => {
    if (target in memo) return memo[target];
    if (target === '') return true;

    for(let word of wordBank) {
        if (target.indexOf(word) === 0){
            const tempTarget = target.slice(word.length);
            if (canConsttruct(tempTarget, wordBank)){
                memo[target] = true
                return true;
            }
        }
    }
    memo[target] = false;
    return false;
}

console.log(canConsttruct("hello", ["hell", "el", "o"]));
console.log(canConsttruct("eeeeeeeeeeeeeeeeeeeeeeeeeef", ["e", "eeeee", "ee","eee"]));
console.log("Next ")
console.log(canConsttructMem("hello", ["hell", "el", "o"]));
console.log(canConsttructMem("eeeeeeeeeeeeeeeeeeeeeeeeeef", ["e", "eeeee", "ee","eee"]));