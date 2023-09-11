export function initialize(inputId, ecAutosuggestDotnetObjectReference, keysToPreventDefault) {
	let inputElement = document.getElementById(inputId);
	if (!inputElement) {
		return;
	}

	inputElement.ecAutosuggestDotnetObjectReference = ecAutosuggestDotnetObjectReference;
	inputElement.ecAutosuggestKeysToPreventDefault = keysToPreventDefault;
	inputElement.clickIsComing = false;

	inputElement.addEventListener('keydown', handleKeyDown);

	inputElement.addEventListener('mousedown', handleMouseDown);
	inputElement.addEventListener('mouseup', handleMouseUp);
}

function handleKeyDown(event) {
	let key = event.key;

	event.target.ecAutosuggestDotnetObjectReference.invokeMethodAsync("EcAutosuggestInternal_HandleInputKeyDown", key);

	if (event.target.ecAutosuggestKeysToPreventDefault.includes(key)) {
		event.preventDefault();
	}
}

export function scrollToSelectedItem(dropdownId) {
	const dropdownElement = document.getElementById(dropdownId);
	if (!dropdownElement) {
		return;
	}

	const selectedItem = dropdownElement.getElementsByClassName("ec-autosuggest-item-focused");
	if (!selectedItem) {
		return;
	}

	selectedItem[0].scrollIntoView({ block: "nearest", inline: "nearest" });
}

export function open(inputElement, ecAutosuggestDotnetObjectReference) {
	if (!inputElement) {
		return;
	}
	inputElement.setAttribute("data-bs-toggle", "dropdown");
	inputElement.ecAutosuggestDotnetObjectReference = ecAutosuggestDotnetObjectReference;
	inputElement.addEventListener('hidden.bs.dropdown', handleDropdownHidden);

	var d = new bootstrap.Dropdown(inputElement);
	if (d && (inputElement.clickIsComing === false)) {
		// clickIsComing logic fixes #575 - Initial suggestions disappear when the DataProvider response is quick
		// If click is coming, we do not want to show the dropdown as it will be toggled by the later click event (if we open it here, onfocus, click will hide it)
		d.show();
	}
}

export function destroy(inputElement) {
	if (!inputElement) {
		return;
	}

	inputElement.removeAttribute("data-bs-toggle", "dropdown");

	var d = bootstrap.Dropdown.getInstance(inputElement);
	if (d) {
		d.hide();
		d.dispose();
	}
}

function handleMouseDown(event) {
	event.target.clickIsComing = true;
}
function handleMouseUp(event) {
	event.target.clickIsComing = false;
}

function handleDropdownHidden(event) {
	event.target.removeEventListener('hidden.bs.dropdown', handleDropdownHidden);

	// In Blazor, jsinterop is "faster" then events.
	// As a result, this method (handleDropdownHidden) is first, dropdown item click event (Blazor OnClick Event) second.
	// But we need the item click event to fire first.
	// Therefore we delay jsinterop for a while.
	window.setTimeout(function (element) {
		element.ecAutosuggestDotnetObjectReference.invokeMethodAsync('EcAutosuggestInternal_HandleDropdownHidden');
	}, 1, event.target);

	var d = bootstrap.Dropdown.getInstance(event.target);
	if (d) {
		d.dispose();
	}
};

export function dispose(inputId) {
	let inputElement = document.getElementById(inputId);

	if (inputElement) {
		inputElement.removeEventListener('keydown', handleKeyDown);
		inputElement.removeEventListener('mouseup', handleMouseUp);
		inputElement.removeEventListener('mousedown', handleMouseDown);
		inputElement.ecAutosuggestDotnetObjectReference = null;
		inputElement.ecAutosuggestKeysToPreventDefault = null;
	}
}
