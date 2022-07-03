
jQuery(document).ready(function($) {	
	var phones = [ ['Iphone XS 512gb', 1500], ['Iphone XS 128gb', 1300], ['Iphone XS 64gb', 1100], ['Iphone XR', 800] ];
	function price(a, b) {
		if (a[1] > b[1]) return 1;
		else if (a[1] < b[1]) return -1; else return 0;
	}
	phones.sort(price);
	for (var i = 0; i < phones.length; i++) {
		console.log(phones[i]);
	}
});

