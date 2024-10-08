async function loadTracks() {
  const response = await fetch('/tracks');
  const tracks = await response.json();
  const trackList = document.getElementById('trackList');
  trackList.innerHTML = '';

  tracks.forEach(track => {
    const div = document.createElement('div');
    div.className = 'track';
    div.innerHTML = `Track ${track.id} <br> Train: ${track.currentTrain ? track.currentTrain.name : 'Empty'}`;
    trackList.appendChild(div);
  });
}

async function loadTrainQueue() {
  const response = await fetch('/queue');
  const trains = await response.json();
  const queue = document.getElementById('trainQueue');
  queue.innerHTML = '';
  trains.forEach(train => {
    const div = document.createElement('div');
    div.className = 'train';
    div.innerHTML = `${train.name}`
    queue.appendChild(div);
  })
}

async function arriveTrain() {
  const newTrain = {
    name: 'Train ' + Math.floor(Math.random() * 100)
  };

  await fetch('/arrive', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(newTrain)
  });

  loadTrainQueue();
}

async function assignTrainToTrack() {
  await fetch('/assign', { method: 'POST' });
  loadTracks();
  loadTrainQueue();
}

async function departTrain() {
  const trackId = prompt('Enter Track ID to depart train:');
  await fetch(`/depart?trackId=${trackId}`, { method: 'POST' });
  loadTracks();
}

loadTracks();
loadTrainQueue();
