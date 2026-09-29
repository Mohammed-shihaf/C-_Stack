import { Link } from 'react-router-dom';
import { loadSession } from '../auth/session';
import { quoteAtFrontDesk } from '../pricing/quoteDesk';
import { quoteAtKiosk } from '../pricing/quoteKiosk';
import { quoteInMobileApp } from '../pricing/quoteMobile';
import { quoteAtTrainerDesk } from '../pricing/quoteTrainer';

export function DashboardPage() {
  const session = loadSession();
  const sampleTenure = 2;
  const sampleMissed = 1;
  const sampleLate = 0;
  const samplePrice = 49;
  const deskQuotes = [
    quoteAtFrontDesk(sampleTenure, sampleMissed, sampleLate, samplePrice),
    quoteAtKiosk(sampleTenure, sampleMissed, sampleLate, samplePrice),
    quoteInMobileApp(sampleTenure, sampleMissed, sampleLate, samplePrice),
    quoteAtTrainerDesk(sampleTenure, sampleMissed, sampleLate, samplePrice),
  ];
  return (
    <main>
      <h1>West Coast Fitness Club</h1>
      <p>Scottsdale and Tucson training floors, memberships, and class reservations.</p>
      <p>Desk quotes for a sample renewal: {deskQuotes.join(', ')}.</p>
      {session ? <p>Signed in as {session.fullName}.</p> : <p>Sign in to book a class or record an assessment.</p>}
      <nav>
        <Link to="/plans">Plans</Link>
        <Link to="/classes">Classes</Link>
        <Link to="/assessments">Assessments</Link>
      </nav>
    </main>
  );
}
