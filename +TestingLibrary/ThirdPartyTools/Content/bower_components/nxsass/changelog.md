#Changelog
## 4.5.8 (Bugfix) 10.14.2014
    changes pathing in app.scss template back to ../../ for more friendly integration with Windows enviros
    
## 4.5.7 (Bugfix) 10.13.2014
    Adds better responsive support to Time Cubes
    Resolves github issues #17 & #18
    
## 4.5.6 (Bugfix) 10.09.2014
    Adds bower.template to shell install
    update Readme with bower init instruction

## 4.5.5 (Bugfix) 10.09.2014
    Changes height of the content on the demo index.html page

## 4.5.4 (Bugfix) 10.02.2014
    Corrects links on the demo index.html

## 4.5.3 (Bugfix) 10.02.2014
    icon-text flips 360 for asymmetrical icons 

## 4.5.2 (Bugfix) 10.01.2014
    Fixes a line-height issue with the icon-text mixin.
    Created _head and _scripts fileIncludes for templates to keep things DRY.

## 4.5.1 (New-ish Feature) 09.30.2014
    Revamped the grid picker (which is now deprecated)
    This includes new special buttons, new "item-component" basic, and new %grid extend.
    Removed maps like in the Iraq and the Asian countries, like such as

## 4.5.0 (New Feature) 09.29.2014
    Adds Quick Values Molecule
    Alphabetizes the molecules like a frikkin master librarian

## 4.4.0 (New Feature) 09.23.2014
    Adds new List Table feature for advanced users.
    
## 4.3.8 (Bug Fix) 09.16.2014
    updates forms, Fixed some heavy handed validation styling for triple class form fields.

## 4.3.7 (Bug Fix) 09.12.2014
    forgot to wrap mobile stuff in mobile breakpoint. Derp.

## 4.3.6 (Bug Fix) 09.12.2014
    Updates with many responsive fixes for mobile devices
    Adds 'content="width=device-width, initial-scale=1.0' meta to docs and index pages
    Refactor of Loader because previous version was ridic.


## 4.3.5 (Bug Fix) 09.02.2014
    fixes width bug with icon-text mixin
    strips default styling of fieldset in _base

## 4.3.4 (New-ish Feature) 08.29.2014
    Update notification system and appearance with new class-system and themes

## 4.2.4 (Bug Fix) 08.28.2014
    Fix color flash/modal thing
    Moved actual molecule partials to the correct folder for docs

## 4.2.3 (Bug Fix) 08.21.2014
    Fixes/Removes table extend line height alignment
    Fixes Responsiveness of Tabbed-subnav more
    Fixes spelling of changelog entry
    Moved molecules lingering in Basics over to Molecules section of docs

## 4.2.2 (Bug Fix) 08.15.2014
    fixes height issue with icon-text

## 4.2.1 (New Features) 08.15.2014
    Fixes bugs with forms error message below
    Adds background to regular form message to fix overlay problems
    fixes icon width in the icon-text module
    fixes padding and alignment with tool-tips
    fixes trash-can button layout problem with uploader 

## 4.2.0 (New Features) 08.14.2014
    Added a beta credit card module

## 4.1.0 (New Features) 08.06.2014
    Renamed flows to Molecules and moved over Tabbed nav and time-cube
    Added icon-text mixin and documentation

## 4.0.2 (Bug Fix) 08.06.2014
    fixed paths in docs _config which were not throwing errors (wut???) 

## 4.0.1 (Bug Fix) 08.04.2014
    little things that were hard-set in nxsass that shouldn't have been, as revealed while implementing the system into another project.
    (potential nxsass base include issues--will discuss with Andrew)
    
## 4.0.0 (JK, Update Required) 08.01.2014
    post commit realising the changes from 3.1.0 should have been a major update, welcome 4.0.0!

## 3.1.0 (New Feature) 08.01.2014
    added font-weight and basesize variables to the map system. 
    This requires you to replace your old variable names with the map reference (recommended), or redefine those variables in your own local styles (not recommended)

## 3.0.1 (Bug Fix)
    remove margin 0 from _form label defaults

## 3.0.0 (Update Required) 07.24.2014
    Moved all documentation into docs and ignored it with bower
    Moved all template and setup files into /source-template
    Created sweet install script with fun graphics. 

## 2.4.5 (Bug Fix) 06.27.2014
    Updates location styling

## 2.4.4 (Bug Fix) 06.25.2014
    Button now uses text font
    
## 2.4.3 (Bug Fix) 06.25.2014
    Derp - set label-text to not float...
    Update padding for the options on the pane--control
    Sets basic max-width for IMG tag
    a tag hover defaults to pointer cursor
    Defaults all form elements to use body font


## 2.4.2 (Bug Fix) 06.25.2014
    Modifies forms to target class="label-text" because label > div was causing some issues.

## 2.4.1 (Minor) 06.24.2014
    Updates Font-Awesome to 4.1.0

## 2.4.0 (New Feature) 06.24.2014
    Adds first "flow" - Customize + Container module.
    Sets html, body to height 100% (needed for customize panes).

## 2.3.0 (New Feature) 06.20.2014
    Adds new Extend: %list--horizontal
    Fixes some style treatment issues with forms.

## 2.2.4 (Bug Fix) 06.17.2014
    Adds box shadow properties to the theme so apps can refine buttons as needed.

## 2.2.3 (Bug Fix) 06.17.2014
    Fixes trash can overlaying the filename in uploader.

## 2.2.2 (Bug Fix) 06.17.2014
    Fixes problem with the height and top of large modal windows

## 2.2.1 (Bug Fix) 06.16.2014
    Adds use-grad to theme. Default value is true, else pass in styles
    Adds use-boxshad to theme. Default to true, else pass box-shadow styles.
    Update modal actions

## 2.2.0 (New Feature) 06.16.2014
    Adds new `toggle--3button`, and `toggle--4button` toggles.

## 2.1.0 (New Feature) 06.11.2014
    New button styles, and matching button variables and a shiny new button mixin file
    Also:
    Time Cube (3d cube rotation) and Tabbed sub-navigation additions in experiments.

## 2.0.7 (Bug Fix) - ) 06.03.2014
    Fixes typo in config.template

## 2.0.6 (Bug Fix) - ) 06.03.2014
    Updates things to match the app-seed.
    Adds .template files to be used in the app-seed.
    Removes some old unused garbage.

## 2.0.5 (Bug Fix) - 05.27.2014
    Extends modal--alert and modal--list with new sizes.

## 2.0.4 (Bug Fix) - 05.23.2014
    Fixed Modal positioning. Adds three variants: modal, modal--small, modal--large
    Widths for these are set in the nxsass `_theme.scss` and can be modified.

## 2.0.3 (Bug Fix) - 05.22.2014
    Lol jk, number fields are all wak in da field (cross browser issues), so for now I am hiding the '!' until I have more time for a robust enterprise solution.
    Also hiding the '!' for check boxes and radios. 

## 2.0.2 (Bug Fix) - 05.22.2014
    alters alignment of the validation ui for select and number fields

## 2.0.1 (Update Required) - 05.20.2014
    removes `_vars`, updates all modules to use `_theme` AFTER looking at `_app-vars`

## 2.0.0 (Update Required) - 05.19.2014
    Major refactor of theme and variables across modules. Modules that call the `nxsass(key, value)` function first look for a map called `$app-vars` and if the key is not found fall back to the `$nxsass-vars` map supplied by the nxsass library. You are free to duplicate and modify any variables as long as you make these changes in `$app-vars` locally. **For existing integrations:** Please copy the `_app-vars.scss` into your base directory and add the `@import` to `_config.scss.` Also, update your local `_config.scss` to include the nxsass `_theme.scss`.

## 1.0.5 (Bug Fix) - 05.16.2014
    Switched the loader--incomm to use a Data URI so you don't need an external gif file.
    Totally refactors gulp into multiple files by task

## 1.0.4 (Bug Fix) - 05.07.2014
    UI update: removes pointer cursor from the already selected side of the toggle--button

## 1.0.3 (Bug Fix) - 05.07.2014
    changes style of the toggle--button to better match the toggle--switch

## 1.0.2 (Bug Fix) - 05.06.2014
    removes underline in button which use links
    fixes alignment of the message--below field error
    fix(toggle, dropdown): makes the button text unselectable

## 1.0.1 (Bug Fix) - 05.01.2014
    adds button[disabled] to button states
    alters _base to use background image from theme: theme(images, background)
    adds default type styles to body as well as paragraph (excluding margins).

## 1.0.0 (Update Required) Initial Release gonna make me lose my mind
    up in here
    up in here