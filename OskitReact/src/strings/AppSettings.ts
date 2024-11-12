
export function useAppSettings() {
	const apiBasePath = "https://localhost/api"
	function createApiPath(pathName: string) {
		return apiBasePath + pathName
	}

	return {
		apiBaseUrl: apiBasePath,
		createApiPath
	}
}