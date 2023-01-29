const apiBaseUrl = 'https://localhost:7091'
export const endpoints = {
    createTenant: () => `${apiBaseUrl}/api/create`,
    loadTenants: () => `${apiBaseUrl}/api/tenants`,
    getTenantUsers: (tenantId) => `${apiBaseUrl}/api/users/${tenantId}`,
    getTenantName: (tenantId) => `${apiBaseUrl}/api/tenant/${tenantId}`,
    updateTenantName: (tenantId) => `${apiBaseUrl}/api/edit/${tenantId}`,
    getCurrentTenantData: (tenantId) => `${apiBaseUrl}/api/users/${tenantId}`,
    resetTenantName: (tenantId) => `${apiBaseUrl}/api/reset/${tenantId}`,
    inviteUser: (tenantId) => `${apiBaseUrl}/api/create/${tenantId}`,
    removeUser: (userId) => `${apiBaseUrl}/api/delete/${userId}`,

    loadTrackers: (tenantId) => `${apiBaseUrl}/api/trackersList/${Number(tenantId)}`,
    createTracker: (tenantId) => `${apiBaseUrl}/api/trackingGroup/create/${tenantId}`,
    createTrackingItem: (tenantId) => `${apiBaseUrl}/api/trackingItems/create/${tenantId}`,
    getTrackingGroupRecords: (trackingGroupId) => `${apiBaseUrl}/api/trackingGroupRecords/${trackingGroupId}`,
    getTrackingGroup: (trackingGroupId) => `${apiBaseUrl}/api/trackers/${trackingGroupId}`,
    updateTrackerName: (trackingGroupId) => `${apiBaseUrl}/api/trackingGroup/edit/${trackingGroupId}`,
    getTrackingGroupTrackingItems: (trackingGroupId) => `${apiBaseUrl}/api/trackingGroup/${trackingGroupId}/trackingItems`,
    resetNames: (trackingGroupId) => `${apiBaseUrl}/api/trackers/${trackingGroupId}`,
    editTracker: (trackerId) => `${apiBaseUrl}/api/editTracker/${trackerId}`
   
    
}