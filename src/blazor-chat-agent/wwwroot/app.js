window.scrollToElement = (element) => {
    if (element) {
        element.scrollIntoView({ behavior: 'smooth', block: 'end' });
    }
};

// Log unhandled errors to the console for debugging
window.addEventListener('error', (event) => {
    console.error('Unhandled error:', event.error);
});

window.addEventListener('unhandledrejection', (event) => {
    console.error('Unhandled promise rejection:', event.reason);
});
