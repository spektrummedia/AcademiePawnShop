"use strict"
/* spk gulpfile

	"gulp" –– watch, process sass/js
	"gulp sync" –– stream sass, reload js/markup
	"gulp build" –– process sass/js
	"gulp prod" –– process sass/js and optimize, wo/ sass silent error
---------------------------------------------------------------------*/
const config = {
	sass: {
		src: [
			'./Sass/*.{scss,sass}'
		],
		dest: './wwwroot/css/',
		options: {indentedSyntax: false}
	},

	js: {
		src: [
            './scripts/site.js',
            './Scripts/fontawesome-all.*'
		],
		dest: './wwwroot/js/'
	},

	jsvendors: {
		src: [
			'./node_modules/bootstrap/dist/js/bootstrap.*',
			'./node_modules/jquery/dist/jquery.slim.*',
			'./Scripts/vendors.js'
		],
		dest: './wwwroot/js/'
	},

	watch: {
		sass: 'Sass/**/*.{scss,sass}',
		js: 'Scripts/**/*.js',
		views: '**/*.{cshtml,html}'
	},

	localhost: 'localhost:5000'
}

/* modules -----------------*/
const gulp = require('gulp');
const concat = require('gulp-concat');
const include = require('gulp-include');
const plumber = require('gulp-plumber');
const notifier = require('node-notifier');
const uglify = require('gulp-uglify');
const autoprefixer = require('autoprefixer');
const mqpacker = require('css-mqpacker');
const cssnano = require('cssnano');
const postcss = require('gulp-postcss');
const sass = require('gulp-sass');
const pxtorem = require('postcss-pxtorem');
const sourcemaps = require('gulp-sourcemaps');
const browserSync = require('browser-sync').create();
const babel = require('gulp-babel');

/* sass ---------------------*/
gulp.task('sass', () => {
	return gulp.src(config.sass.src)
		.pipe(plumber(function(err) {
			let title = `Sass Error -> ${err.relativePath}:${err.line}`
			notifier.notify({title: title, message: err.messageOriginal.replace(/\s{4}/,'')});
			console.log('\n', title, '\n\t', err.messageOriginal.replace(/\s{4}/,''), '\n');
			this.emit('end');
		}))
		.pipe(sourcemaps.init())
		.pipe(sass(config.sass.options))
		.pipe(postcss([
			// pxtorem, // remove comment if you wish to use this feature
			mqpacker,
			autoprefixer({browsers: ['last 2 versions', 'ie 10', 'iOS 7-8']})
		]))
		.pipe(sourcemaps.write())
		.pipe(gulp.dest(config.sass.dest))
		.pipe(browserSync.stream());
});

gulp.task('sass:min', () => {
	return gulp.src(config.sass.src)
		.pipe(sass(config.sass.options))
		.pipe(postcss([
			// pxtorem, // remove comment if you wish to use this feature
			mqpacker,
			autoprefixer({browsers: ['last 2 versions', 'ie 10', 'iOS 7-8']}),
			cssnano
		]))
		.pipe(gulp.dest(config.sass.dest))
});


/* js ----------------------*/
gulp.task('js', () => {
	return gulp.src(config.js.src)
		.pipe(include())
		.pipe(babel({
	        presets: ['env']
	    }))
		.pipe(gulp.dest(config.js.dest));
});

/* jsvendors ----------------------*/
gulp.task('jsvendors', () => {
	return gulp.src(config.jsvendors.src)
		.pipe(include())
		.pipe(gulp.dest(config.jsvendors.dest));
});

gulp.task('js:min', ['js'], () => {
	if (config.js.dest.slice(-1)[0] === '/') {
		return gulp.src(`${config.js.dest}*.js`)
			.pipe(uglify())
			.pipe(gulp.dest(config.js.dest));
	} else {
		notifier.notify({title: 'Gulp Config Error', message: '"config.js.dest" must end with a forward slash'});
		console.log('\nGulp Config Error\n\t"config.js.dest" must end with a forward slash\n');
	}
});


/* builds ------------------*/
gulp.task('build', ['sass', 'js', 'jsvendors']);
gulp.task('prod', ['sass:min', 'js:min']);


/* dev ---------------------*/
gulp.task('default', ['build'], () => {
	gulp.watch(config.watch.sass, ['sass']);
	gulp.watch(config.watch.js, ['js']);
});


/* browser sync ------------*/
gulp.task('sync', ['default'], () => {
	if (config.js.dest.slice(-1)[0] === '/') {
		let bsConfig = config.localhost
			? {proxy: config.localhost}
			: {server: './'};

		browserSync.init(bsConfig);

		gulp.watch(`${config.js.dest}*.js`).on('change', browserSync.reload);
		gulp.watch(config.watch.views).on('change', browserSync.reload);
	} else {
		notifier.notify({title: 'Gulp Config Error', message: '"config.js.dest" must end with a forward slash'});
		console.log('\nGulp Config Error\n\t"config.js.dest" must end with a forward slash\n');
	}
});
