export function initialize(element, ecCollapseDotnetObjectReference, shouldToggle) {
	if (!element) {
		return;
	}

	element.ecCollapseDotnetObjectReference = ecCollapseDotnetObjectReference;
	element.addEventListener('show.bs.collapse', handleCollapseShow);
	element.addEventListener('shown.bs.collapse', handleCollapseShown);
	element.addEventListener('hide.bs.collapse', handleCollapseHide);
	element.addEventListener('hidden.bs.collapse', handleCollapseHidden);

	var c = new bootstrap.Collapse(element, {
		toggle: shouldToggle,
	});
}

export function show(element) {
	var c = bootstrap.Collapse.getInstance(element);
	if (c) {
		c.show();
	}
};

export function hide(element) {
	var c = bootstrap.Collapse.getInstance(element);
	if (c) {
		c.hide();
	}
};

function handleCollapseShow(event) {
	event.target.ecCollapseDotnetObjectReference.invokeMethodAsync('EcCollapse_HandleJsShow');
};
function handleCollapseShown(event) {
	event.target.ecCollapseDotnetObjectReference.invokeMethodAsync('EcCollapse_HandleJsShown');
};
function handleCollapseHide(event) {
	event.target.ecCollapseDotnetObjectReference.invokeMethodAsync('EcCollapse_HandleJsHide');
};
function handleCollapseHidden(event) {
	event.target.ecCollapseDotnetObjectReference.invokeMethodAsync('EcCollapse_HandleJsHidden');
};

export function dispose(element) {
	if (!element) {
		return;
	}

	element.removeEventListener('show.bs.collapse', handleCollapseShow);
	element.removeEventListener('shown.bs.collapse', handleCollapseShown);
	element.removeEventListener('hide.bs.collapse', handleCollapseHide);
	element.removeEventListener('hidden.bs.collapse', handleCollapseHidden);
	element.ecCollapseDotnetObjectReference = null;

	var c = bootstrap.Collapse.getInstance(element);
	if (c) {
		c.dispose();
	}
}
