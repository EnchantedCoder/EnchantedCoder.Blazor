export function initialize(inputId, ecSearchBoxDotnetObjectReference, keysToPreventDefault) {
	let inputElement = document.getElementById(inputId);
	if (!inputElement) {
		return;
	}

    inputElement.ecSearchBoxDotnetObjectReference = ecSearchBoxDotnetObjectReference;
	inputElement.ecSearchBoxKeysToPreventDefault = keysToPreventDefault;

    inputElement.addEventListener('keydown', handleKeyDown);
}

function handleKeyDown(event) {
    let key = event.key;

    event.target.ecSearchBoxDotnetObjectReference.invokeMethodAsync("EcSearchBox_HandleInputKeyDown", key);

	if (event.target.ecSearchBoxKeysToPreventDefault.includes(key)) {
        event.preventDefault();
    }
}

export function dispose(inputId) {
    let inputElement = document.getElementById(inputId);

    inputElement.removeEventListener('keydown', handleKeyDown);
    inputElement.ecSearchBoxDotnetObjectReference = null;
	inputElement.ecSearchBoxKeysToPreventDefault = null;
}
