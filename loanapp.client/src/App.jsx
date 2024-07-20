import { useEffect, useState } from 'react';
import './App.css';

function App() {
  const [users, setUsers] = useState([]);
  const [selectedUser, setSelectedUser] = useState('');
  const [loanAmount, setLoanAmount] = useState('');
  const [loanPeriod, setLoanPeriod] = useState('');
  const [message, setMessage] = useState('');
  const [alertType, setAlertType] = useState('');

  const handleLoanAmountChange = (event) => {
    setLoanAmount(event.target.value);
  };

  const handleLoanPeriodChange = (event) => {
    setLoanPeriod(event.target.value);
  };

  const handleLoanSuggestion = (event) => {
    event.preventDefault();
    getLoanSuggestion();
  };

  const handleUserChange = (event) => {
    let user = users.find(u => u.id == event.target.value);
    setSelectedUser(user);
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const fetchUsers = async () => {
    try {
      const response = await fetch('/users/getUsers', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: '{}'
      });
      if (response.ok) {
        let responseData = await response.json();
        setUsers(responseData.users);
      }
    } catch (error) {
      console.error('Error fetching users:', error);
    }
  };

  return (
    <div className="container mt-4">


      <form onSubmit={handleLoanSuggestion}>
        <div className="form-group">
          <label>Select User:</label>
          <select
            className="form-control"
            value={selectedUser.id}
            onChange={handleUserChange}
            required
          >
            {users && users.map(user => (
              <option key={user.id} value={user.id}>
                {`Name: ${user.name};
                  Age: ${user.age}`}
              </option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label>Loan Amount:</label>
          <input
            type="number"
            className="form-control"
            value={loanAmount}
            min={1}
            onChange={handleLoanAmountChange}
            required
          />
        </div>
        <div className="form-group">
          <label>Loan Period:</label>
          <input
            type="number"
            className="form-control"
            value={loanPeriod}
            onChange={handleLoanPeriodChange}
            min={12}
            required
          />
        </div>
        <button type="submit" className="btn btn-primary mt-5 mb-3">
          Get Loan Suggestion
        </button>
      </form>

      <div className={alertType} role="alert" >
        {message}
      </div>
    </div>
  );

  async function getLoanSuggestion() {
    const response = await fetch('loan/getLoanSuggestion', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        Age: selectedUser.age,
        Amount: loanAmount,
        LoanPeriodInMonths: loanPeriod
      })
    });

    if (response.ok) {
      const data = await response.json();
      if (data.success) {
        setAlertType('alert alert-success');
        setMessage(`Total amount to pay: ${data.totalAmountToPay}`);
      }
      else {
        setAlertType('alert alert-danger');
        setMessage(data.message);
      }
    }
    else {
      setAlertType('alert alert-danger');
      setMessage('Ooops something wrong with the server. Please try again later'); // 
    }
  }
}

export default App;