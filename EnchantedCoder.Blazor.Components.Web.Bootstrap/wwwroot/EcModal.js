export function show(element, ecModalDotnetObjectReference, closeOnEscape, subscribeToHideEvent) {
	if (!element) {
		return;
	}

	element.ecModalDotnetObjectReference = ecModalDotnetObjectReference;
	if (subscribeToHideEvent)
		element.addEventListener('hide.bs.modal', handleModalHide);
	element.addEventListener('hidden.bs.modal', handleModalHidden);
	element.addEventListener('shown.bs.modal', handleModalShown);

	var modal = new bootstrap.Modal(element, {
		keyboard: closeOnEscape
	});
	if (modal) {
		modal.show();
	}
}

export function hide(element) {
	var modal = bootstrap.Modal.getInstance(element);
	if (modal) {
		modal.hide();
	}
}

function handleModalShown(event) {
	event.target.ecModalDotnetObjectReference.invokeMethodAsync('EcModal_HandleModalShown');
};

async function handleModalHide(event) {
    let modalInstance = bootstrap.Modal.getInstance(event.target);

	if (modalInstance.hidePreventionDisabled)
        return;

    event.preventDefault();

    let cancel = await event.target.ecModalDotnetObjectReference.invokeMethodAsync('EcModal_HandleModalHide');
    if (!cancel) {
		modalInstance.hidePreventionDisabled = true;
        modalInstance.hide();
    }
};

function handleModalHidden(event) {
	event.target.ecModalDotnetObjectReference.invokeMethodAsync('EcModal_HandleModalHidden');
	dispose(event.target);
};

export function dispose(element) {
	if (!element) {
		return;
	}

	element.removeEventListener('hide.bs.modal', handleModalHide);
	element.removeEventListener('hidden.bs.modal', handleModalHidden);
	element.removeEventListener('shown.bs.modal', handleModalShown);
	element.ecModalDotnetObjectReference = null;

	var modal = bootstrap.Modal.getInstance(element);
	if (modal) {
		modal.dispose();
	}
}