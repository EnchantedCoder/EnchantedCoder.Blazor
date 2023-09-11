// has to be aligned with EcPopover.js!
export function initialize(element, ecDotnetObjectReference, options) {
	if (!element) {
		return;
	}
	element.ecDotnetObjectReference = ecDotnetObjectReference;
	element.addEventListener('shown.bs.tooltip', handleShown);
	element.addEventListener('hidden.bs.tooltip', handleHidden);
	new bootstrap.Tooltip(element, options);
}

export function show(element) {
	var i = bootstrap.Tooltip.getInstance(element);
	if (i) {
		i.show();
	}
}

export function hide(element) {
	var i = bootstrap.Tooltip.getInstance(element);
	if (i) {
		i.hide();
	}
}

export function enable(element) {
	var i = bootstrap.Tooltip.getInstance(element);
	if (i) {
		i.enable();
	}
}

export function disable(element) {
	var i = bootstrap.Tooltip.getInstance(element);
	if (i) {
		i.disable();
	}
}

export function setContent(element, newContent) {
	var i = bootstrap.Tooltip.getInstance(element);
	if (i) {
		i.setContent(newContent);
	}
}

function handleShown(event) {
	event.target.ecDotnetObjectReference.invokeMethodAsync('EcHandleJsShown');
};

function handleHidden(event) {
	event.target.ecDotnetObjectReference.invokeMethodAsync('EcHandleJsHidden');
};

export function dispose(element) {
	if (!element) {
		return;
	}
	element.removeEventListener('shown.bs.tooltip', handleShown);
	element.removeEventListener('hidden.bs.tooltip', handleHidden);
	element.ecDotnetObjectReference = null;
	var tooltip = bootstrap.Tooltip.getInstance(element);
	if (tooltip) {
		tooltip.dispose();
	}
}