import React, { useEffect, useState } from 'react';
import './App.css';
import axios from 'axios';
import { Button, Header } from 'semantic-ui-react';
import List from 'semantic-ui-react/dist/commonjs/elements/List';

function App() {
	const [activities, setActivities] = useState<any>([]);

	useEffect(() => {
		axios.get('http://localhost:5000/api/activities')
			.then(response => {
				setActivities(response.data);
			})
	}, [])

	return (
		<div>
			<Header as='h2' icon='users' content='Reactivities' />
			<List>
				{activities.map((activity: any) =>
					<List.Item key={activity.id}>{activity.title}</List.Item>
				)}
			</List>
			<Button content='Test' />
		</div>
	);
}

export default App;
