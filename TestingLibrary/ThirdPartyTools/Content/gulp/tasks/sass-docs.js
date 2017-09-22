var gulp          = require('gulp');
var notify        = require('gulp-notify');
var sass          = require('gulp-sass');
var gutil         = require('gulp-util');
var plumber       = require('gulp-plumber');
var autoprefixer  = require('gulp-autoprefixer');
var path          = require('path');
var livereload    = require('gulp-livereload');
var lr            = require('tiny-lr')();
var config        = require('../config-docs');
var useRubySass = true;


function handleError(err) {
  gutil.log(err);
  gutil.beep();
}

function runSass() {
  var sassPipe;
  if (!useRubySass) {
    var sass = require('gulp-sass');
    sassPipe = sass({
      style: 'compact',
      errLogToConsole: true
    });
  } else {
    var rubysass = require('gulp-ruby-sass');
    sassPipe = rubysass({
      sourcemap: true,
      noCache: true,
      style: 'compact'
    });
  }

  return gulp.src(path.join(config.paths.sass, '*.scss'))
    .pipe(plumber())
    .pipe(sassPipe)
    .on('error', handleError)
    .pipe(autoprefixer('last 2 version', "> 1%", 'ie 8', 'ie 9'))
    .on('error', handleError)
}

gulp.task('sass-docs', function () {
  var message;
  if (!useRubySass) {
    message = 'Sass files compiled';
  } else {
    message = 'Sass (with Ruby) files compiled';
  }

  return runSass()
    .pipe(gulp.dest('./docs/css'))
    .pipe(livereload(lr))
    .pipe(notify({
      message: message
    }));
});