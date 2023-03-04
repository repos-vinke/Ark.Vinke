# Ark.Vinke
Integration based modular system

### Environment Structure

- Ark								<- Product Name
	- Default						<- Environment Name (Free for choice)
		- Debug						<- Runtime debug folder (Must be 'Debug')
			- Both					<- Runtime both side (Must be 'Both')
			- Client				<- Runtime client side (Must be 'Client')
			- Server				<- Runtime server side (Must be 'Server')
		- Release					<- Runtime release folder (Must be 'Release')
			- Both					<- Runtime both side (Must be 'Both')
			- Client				<- Runtime client side (Must be 'Client')
			- Server				<- Runtime server side (Must be 'Server')
		- Repos						<- Repository collection folder (Free for choice - Prefer 'Repos')
			- Lazy.Vinke    <- Repository folder (Clone Lazy to here)
			- Ark.Vinke     <- Repository folder (Clone Ark to here)
