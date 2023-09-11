export function show(element, ecToastDotnetObjectReference) {
	if (!element) {
		return;
	}

	element.ecToastDotnetObjectReference = ecToastDotnetObjectReference;
	element.addEventListener('hidden.bs.toast', handleToastHidden);

	var toast = new bootstrap.Toast(element);
	if (toast) {
		toast.show();
	}
}

function handleToastHidden(event) {
	event.target.ecToastDotnetObjectReference.invokeMethodAsync('EcToast_HandleToastHidden');
};

export function dispose(element) {
	if (!element) {
		return;
	}

	element.removeEventListener('hidden.bs.toast', handleToastHidden);
	element.ecToastDotnetObjectReference = null;

	var t = bootstrap.Toast.getInstance(element);
	if (t) {
		t.dispose();
	}
}