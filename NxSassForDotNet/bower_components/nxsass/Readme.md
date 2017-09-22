# nxsass

_Pronounced like Nex-Us_

We are using a hybrid of B.E.M. and SMACSS -- two OOCSS approaches [outlined here](https://medium.com/objects-in-space/f6f404727) to structure our projects, and naming conventions.

## A Collection of UI Modules as Sass Objects

You will be importing sass modules into your current project - not css. Modules should be included in your `app.scss` manifest file. We suggest only including the items that you need. You will need to use a tool for compiling Sass, autoprefixing, and outputting the files into one minified production css file.

## Simple Bower Install

If you _already_ have Bower (and Node), simply include nxsass:

    bower install git@github.com:InCommDigitalSolutions/nxsass.git#<version> --save-dev

_Note: You need to provide the full git url because this project is private._

### Updating

Update the nxsass version number in your `bower.json` file e. g.

    "nxsass": "git@github.com:InCommDigitalSolutions/nxsass.git#4.0.0"

Then run

    bower update

## Advanced Development Setup

Using `install_nxsass.sh`. Navigate to the directory where you want/have your `/css` directory.

If you do not have a bower.json file here, you need to run:

    bower init

Next, install and add nxsass with bower:

    bower install git@github.com:InCommDigitalSolutions/nxsass.git#<version> --save-dev

Navigate into the nxsass directory:

    cd bower_components/nxsass

The install script needs permissions to execute:

    chmod a+x install_nxsass.sh

Now just run it:

    ./install_nxsass.sh

Everything should be ready to go. Go up to the directory with the index.html file and run:

    gulp

You should see a nicely styled welcome page here: [http://localhost:1337](http://localhost:1337)

### Manual Setup and Test

We provide a default structure for using Sass and compiling CSS. 

1. Sass Structure: Create or find your `/css` directory. Copy `/source-template` into your `/css` directory. 
2. Rename directory to `/source`
3. Tools: Copy `package.json`, `gulpfile.js`, `/gulp`, and `index.html` in `root`

Now run:
    
    npm install

Once complete, your structure should look similar to this:
    
    |-bower_components
    |-css
        |-source
            |-base
            |-module
            app.scss
    |-gulp
    |-node_modules
    index.html
    gulpfile.js
    package.json

Now run the default gulp task:

    gulp

This creates a server with livereload and watches scss files in css/source and compiles them on save. css/source/app.scss will be compiled to css/app.css.

The server defaults to here: [http://localhost:1337](http://localhost:1337) where you can view our demo test page.

## Missing Node, Sass, Bower, and/or Gulp?

### Sass

Install [Sass v3.3.4](http://sass-lang.com/install)

    gem install sass

You may need to run `sudo gem install sass` using a Mac. Check your version with `sass -v`

### Node, Bower, Gulp

You will need [node](http://nodejs.org/). Then install bower and gulp globally

    npm install -g bower gulp

 _Mac: You may need to use `sudo`._

 Next - return to [Directory Setup and Test](#directory-setup-and-test) above.


### Optional Gulp Task

Compile Sass only:

    gulp sass

## Documentation Development

You need the full repo pulled down from git. Then run:

    npm install

    bower install

### Docs gulp task

    gulp dev

The Documentation lives here: [http://localhost:1337/docs](http://localhost:1337/docs).

## Requesting Features

We intend to use github's issue tracker for managing new feature requests, enhancements, and bugs. You are encourage to add these [as needed here](https://github.com/InCommDigitalSolutions/nxsass/issues).

## Release Notes

nxsass will follow [semantic versioning](http://semver.org/) for releases. We will be maintaining a log of changes using the **changelog.md** (see project root). Each release will have a type which represents a high level summary of the release. 

- **Bug Fixes** should require nothing more than an update of nxsass 
- **New Feature** will add new functionality that does not touch existing modules
- **Update Required** will include changes to existing modules and will require updating of existing code. We will try to avoid this type of update as much as possible. 

## Foundation and Dependencies 

Our base depends on [Normalize](http://necolas.github.io/normalize.css/), and we utilize [Bourbon](bourbon.io). When building sass you **must** also use [autoprefixer](https://www.npmjs.org/package/gulp-autoprefixer), which handles browser compatibility and extensions. Here is [a breakdown](https://medium.com/objects-in-space/2fd5f9821fc4) of our nxsass build tool which uses [Gulp](http://gulpjs.com/). 

## SCSS Files

### app.scss

The main production scss file is `app.scss`. This file is the manifest to `@import` other scss libraries. e.g.

    //app.scss


    //base
    @import "base/_config"; 

    //nxsass modules
    @import "../../vendor/nxsass/css/source/module/_button";
    @import "../../vendor/nxsass/css/source/module/_form";
    @import "../../vendor/nxsass/css/source/module/_loader";
    @import "../../vendor/nxsass/css/source/module/_modal";

    //local modules
    @import "module/_nav";
    @import "module/_discount";
    @import "module/_login";
    @import "module/_welcome";
    @import "module/_view-orders";

### base/_config.scss

Our base items will build a foundation for your site's styles. Your local `_config.scss` file should `@import` base items like Bourbon, and then the nxsass Mixins, and general site design elements like color and fonts. These includes will set up the general global variables and common values. For example:

    @import "../../vendor/bourbon/app/assets/stylesheets/_bourbon";
    @import "_mixins";    //point to nxsass
    @import "_app-vars";  //<- copy this and then point to LOCAL file
    @import "_theme";     //point to nxsass
    @import "_extends";   //point to nxsass
    @import "_base";      //point to nxsass
    @import "_states";    //point to nxsass AND you can create your own local version as needed

Every application will likely have it's own set of variables which will go in a local `_app-vars.scss` file. nxsass includes a template for your local `_app-vars.scss` and a required base theme in `_theme.scss`. This theme file is the fall-back for any nxsass variables _not_ defined or over-ridden in your `_app-vars`.

### Modules

Modules should be included as needed from our scss src directory. Your own custom app only modules should be created and added to the local /module folder.

#### Code Pattern

Attempting to make child and grandchild components of modules independent of their parent containers.

*SCSS:*

    .my-module {
      // ...
    }

    .my-module__child-component{ // <- this handles the layout of child component
      width: 100px
    }
    .child-component { // <- child component is a new stand-alone module
      // ...
    }
    .child-component__grandchild-component {
      position: absolute
      top: 10px
    }

*markup:*

    <div class="my-module">

      <div class="my-module__child-component">
        <div class="child-component is-active">

          <div class="child-component__grandchild-component">
            <div class="grandchild-component--modifier"></div>
          </div>

        </div>
      </div>

    </div> 


#### Code Pattern

Module-specific state classes are defined in the same file as the module itself (see `.is-active` above). The scss for a module specific state should always [use the AND selector](http://www.w3.org/TR/selectors/#class-html) to avoid conflicts:

    .object.is-minified {}

We keep **global** state classes separate and these are rare, and always very general, e.g. `.is-hidden`.

    .is-collapsed {
      display:none;
    }