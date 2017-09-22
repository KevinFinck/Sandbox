// When loading a configuration file, we have the choice to load either .js file,
// which will be interpreted as a JavaScript module file, with the "exports" being
// returned from the require; or, we can load a .json file, which will be parsed as
// JavaScript Object Notation (JSON) with the result being returned from the require.

// Load configuration as JSON.
console.log( "JSON File:" );
console.log( require( "./config.json" ) );

// Load configuration as module.
console.log( "MODULE File:" );
console.log( require( "./config.js" ) );



// When loading a configuration file, we don't have to lock ourselves into a particular
// type of file. If we exclude the file-extension, Node will automatically try to look
// for a *.js and then, if not found, a *.json file. This means that we can start out
// using a .json file; then, if we need to add a programmatic aspect to the config file,
// we can transparently change it over to a "module" style file. The take-away here is
// that there is absolutely no reason to NOT start out with a .json file if your module
// just returns a static hash.

// Load configuration as UNKNOWN file type.
// --
// NOTE: On disk, it is "config.json". But, we're going to make Node.js look for it.
console.log( "UNKNOWN File:" );
console.log( require( "./config" ) );
