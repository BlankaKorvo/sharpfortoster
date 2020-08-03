pipeline {
  agent {
    node {
      label 'ubuntu_agent_netcore3'
    }

  }
  stages {
    stage('test') {
      steps {
        sh 'dotnet test addressbook-web-test/addressbook-web-test.sln --logger "trx;LogFileName=resultfile.trx"'
      }
    }

  }
  post {
    always {
      emailext(attachLog: true, to: 'a.vergel@radico.ru', from: 'autotoster@radico.ru', subject: "${currentBuild.result} test ${currentBuild.fullDisplayName}", body: "Tests Report: ${env.RUN_DISPLAY_URL}")
      archiveArtifacts(artifacts: 'addressbook-web-test/addressbook-web-test/TestResults/*.trx', fingerprint: true)
      nunit(testResultsPattern: 'addressbook-web-test/addressbook-web-test/TestResults/TestResults/*.xml')
      mstest(testResultsFile: 'addressbook-web-test/addressbook-web-test/TestResults/*.trx, keepLongStdio: true')
    }

  }
  triggers {
    upstream(upstreamProjects: 'IDKAPIServer/master', threshold: hudson.model.Result.SUCCESS)
  }
}