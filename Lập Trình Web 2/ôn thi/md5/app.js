const MD5 = require('md5.js');

/* 
console.log(new MD5().update('42').digest('hex'))
// => a1d0c6e83f027327d8461063f4ac58a6
 
var md5stream = new MD5()
md5stream.end('42')
console.log(md5stream.read().toString('hex'))
// => a1d0c6e83f027327d8461063f4ac58a6
*/

const raw = '42';
const hash = new MD5().update(raw).digest('hex');

console.log(hash);